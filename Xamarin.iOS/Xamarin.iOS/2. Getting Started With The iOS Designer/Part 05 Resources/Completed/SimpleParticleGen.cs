using System;
using System.Drawing;
using System.Diagnostics;
using UIKit;
using CoreGraphics;

namespace Fireworks
{
	public class SimpleParticleGen
	{
		UIImage imgParticle;
		UIView parent;
		CGPoint location;

		public nfloat durrationMin { get; set; }
		public nfloat durrationMax { get; set; }
		public nfloat delayMin { get; set; }
		public nfloat delayMax { get; set; }
		public nfloat immortalDelay { get; set; }

		public nfloat scaleMin { get; set; }
		public nfloat scaleMax { get; set; }
		public nfloat scaleStart { get; set; }

		public nfloat alphaStart { get; set; }
		public nfloat alphaFinal { get; set; }

		public int numberOfParticles { get; set; }

		public int distanceMin { get; set; }
		public int distanceMax { get; set; }

		public bool destroyParticles { get; set; }
		public bool continousParticles { get; set; }

		private bool isRunning;

		Random random = new Random( System.DateTime.Now.Second );

		public SimpleParticleGen (UIImage imageParticle, UIView parent, CGPoint position)
		{
			this.imgParticle = imageParticle;
			this.parent = parent;
			this.location = position;

			SetDefaults ();
		}

		public void SetDefaults ()
		{
			numberOfParticles = 100;
			durrationMin = 1;
			durrationMax = 2;
			delayMin = 0;
			delayMax = 0.25f;
			immortalDelay = 0.5f; //time between immortal particles

			scaleMin = 0.25f;
			scaleMax = 1.0f;
			scaleStart = 0.01f;

			distanceMin = 50;
			distanceMax = 140;

			alphaStart = 1;
			alphaFinal = 0;

			destroyParticles = true;
			continousParticles = false;
		}

		CGPoint GetRandomPosition(nfloat scale)
		{
			//get random angle (radians) and distance
			double radius = random.Next(distanceMin, distanceMax);
			double angle = random.NextDouble () * 2 * Math.PI;  

			//convert to cartisian
			var xPos = (nfloat)(radius * Math.Cos(angle));
			var yPos = (nfloat)(radius * Math.Sin(angle));

			//offset for upper left origin
			xPos -= (scaleStart)*imgParticle.Size.Width / 2;
			yPos -= (scaleStart)*imgParticle.Size.Height / 2;


			return new CGPoint (xPos + location.X, yPos + location.Y); 
		}

		nfloat GetRandomScale()
		{
			if(scaleMin == scaleMax)
				return scaleMax;

			return (nfloat)random.NextDouble() * (scaleMax - scaleMin) + scaleMin;
		}

		void NewParticle (CGPoint startPosition, Action complete )
		{
			nfloat scale = 1;

			var particle = new UIImageView (imgParticle) 
			{
				Alpha = alphaStart,
			};

			if(scaleStart != 1.0f)
			{
				particle.Transform = CGAffineTransform.MakeScale(scaleStart, scaleStart);
			}

			particle.SetLocation ( startPosition );

			parent.Add (particle);

			UIView.Animate (random.NextDouble () * (durrationMax - durrationMin) + durrationMin, random.NextDouble () * (delayMax - delayMin) + delayMin, 
				UIViewAnimationOptions.CurveEaseOut, 
				() => 
				{
					scale = GetRandomScale ();

					particle.SetLocation (GetRandomPosition (scale));
					if (scaleStart != scale)
					{
						particle.Transform = CGAffineTransform.MakeScale (scale, scale);
					}
					if (alphaFinal != alphaStart) 
					{
						particle.Alpha = alphaFinal;
					}
				}, 
				() => {
					if (destroyParticles == true) 
					{
						particle.RemoveFromSuperview ();
						particle = null;
					}
					if (complete != null)
						complete ();
				});

		}

		void StartContinuousParticles ()
		{
			isRunning = true;

			nfloat xOffSet = imgParticle.Size.Width*scaleStart/2;
			nfloat yOffSet = imgParticle.Size.Height*scaleStart/2;

			var startLoc = new CGPoint(location.X - xOffSet, location.Y - yOffSet);

			for(int i = 0; i < numberOfParticles; i++)
				GetImmortalParticle(startLoc);
		}

		void GetImmortalParticle (CGPoint startLoc)
		{
			NewParticle (startLoc, () => 
			{
				if (isRunning == true)
				{
					GetImmortalParticle (startLoc);
				}
			});
		}

		public void Start ()
		{
			if(continousParticles == true)
			{
				if (isRunning == true)
					Stop ();

				StartContinuousParticles();
				return;
			}

			nfloat xOffSet = imgParticle.Size.Width*scaleStart/2;
			nfloat yOffSet = imgParticle.Size.Height*scaleStart/2;

			var startLoc = new CGPoint(location.X - xOffSet, location.Y - yOffSet);

			for (int i = 0; i < numberOfParticles; i++)
			{
				NewParticle(startLoc, null);
			}
		}

		public void Stop ()
		{
			isRunning = false;
		}


	}

	public static class Extensions
	{
		public static void SetLocation(this UIView view, nfloat left, nfloat top)
		{
			if (view != null)
				view.Frame = new CGRect (new CGPoint (left, top), view.Frame.Size);
		}


		public static void SetLocation(this UIView view, CGPoint point)
		{
			if(view != null)
				view.Frame = new CGRect(point, view.Frame.Size);
		}
	}
}