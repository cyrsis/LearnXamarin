using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using UIKit;
using CoreGraphics;
using Foundation;

namespace Mailbox
{
    public sealed class EmailServer
    {
        public IList<EmailItem> Email {get; private set;}
        public static string UserName { get; set; }

        const string DefaultUserName = "Johnny Appleseed";

        static EmailServer()
        {
            UserName = DefaultUserName;
        }

        public EmailServer (int count = 10)
        {
            Email = new List<EmailItem> ();
            Generate (count);
        }

        public async Task Refresh()
        {
            await Task.Delay(DataGenerator.RNG.Next(5000));
            await Task.Run(() => {
                Generate(DataGenerator.RNG.Next(10));
            });
        }

        void Generate (int count)
        {
            for (int index = 0; index < count; index++) {
                Email.Insert (0, CreateOneEmail ());
            }
        }

        EmailItem CreateOneEmail ()
        {
            return new EmailItem {
                To = UserName ?? DefaultUserName,
                From = DataGenerator.Name,
                Subject = DataGenerator.GenerateSentence(DataGenerator.RNG.Next(4,8)),
                Body = DataGenerator.GenerateParagraphs(DataGenerator.RNG.Next(3,5),
                    DataGenerator.RNG.Next(3), DataGenerator.RNG.Next(4,8), 
                    DataGenerator.RNG.Next(4), DataGenerator.RNG.Next(5,20))
            };
        }
    }

    public static class DataGenerator
    {
        static readonly StringBuilder _builder = new StringBuilder();
        static string[] _words;

        static string[] _firstName = {
            "Alice", "Bob", "Charlie", "David", "Elliot", "Francis", "George",
            "Harry", "Isabelle", "Jackie", "Karen", "Lenny", "Michael", "Nancy",
            "Otto", "Peter", "Ron", "Steve", "Trevor", "Uma", "Violet", "Yvonne", "Zoe"
        };

        static string[] _lastName = {
            "Ackard", "Baker", "Candy", "Duvall", "Ennis", "Finch", "Griswold", "Heck",
            "Jackson", "Kardashian", "Lewis", "Miller", "Nevell", "Octavius", "Parker",
            "Rivest", "Smith", "Taylor", "Stewart"
        };

        static public Random RNG = new Random();

        static DataGenerator ()
        {
            _words = File.ReadAllLines (@"words.txt");
        }

        public static string Name
        {
            get { return _firstName[RNG.Next(_firstName.Length-1)] + " " + _lastName[RNG.Next(_lastName.Length-1)]; }
        }

        public static string GenerateParagraphs(int numberParagraphs, int minSentences,
                                         int maxSentences, int minWords, int maxWords)
        {
            _builder.Clear ();

            for (int i = 0; i < numberParagraphs; i++)
            {
                AddParagraph(RNG.Next(minSentences, maxSentences + 1), minWords, maxWords);
                _builder.Append("\n\n");
            }

            return _builder.ToString ();
        }

        public static string GenerateSentence(int numberWords)
        {
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < numberWords; i++)
            {
                b.Append(_words[RNG.Next(_words.Length)]).Append(" ");
            }

            string sentence = b.ToString().Trim() + ". ";
            sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);
            return sentence;
        }

        static void AddParagraph(int numberSentences, int minWords, int maxWords)
        {
           for (int i = 0; i < numberSentences; i++)
           {
                int count = RNG.Next(minWords, maxWords + 1);
                AddSentence(count);
            }
        }

        static void AddSentence(int numberWords)
        {
            _builder.Append(GenerateSentence(numberWords));
        }
    }

    public sealed class EmailItem
    {
        public string From {get;set;}
        public string To {get;set;}
        public string Subject {get;set;}
        public string Body {get;set;}
        public DateTime Date {get;set;}

        public EmailItem ()
        {
            Date = DateTime.Now;
        }

        private readonly CGColor[] colors = {
            UIColor.Red.CGColor,
            UIColor.Blue.CGColor,
            UIColor.Brown.CGColor,
            UIColor.DarkGray.CGColor,
            UIColor.Magenta.CGColor,
            UIColor.Orange.CGColor,
            UIColor.Purple.CGColor,
        };

        public override string ToString()
        {
            return string.Format("{2}, From={0}, To={1}, Date={3}]", From, To, Subject, Date);
        }

        public UIImage GetImage()
        {
            nfloat width = 32;
            nfloat height = 32;

            CGColor color = colors[DataGenerator.RNG.Next(colors.Length - 1)];

            UIFont font = UIFont.FromName("Helvetica Light", 14);
            UIGraphics.BeginImageContextWithOptions(new CGSize(width,height), false, 0);

            var context = UIGraphics.GetCurrentContext();
            context.SetFillColor(color);
            context.AddArc(width / 2, height / 2, width / 2, 0, (nfloat)(2 * Math.PI), true);
            context.FillPath();

            var textAttributes = new UIStringAttributes {
                ForegroundColor = UIColor.White,
                BackgroundColor = UIColor.Clear,
                Font = font,
                ParagraphStyle = new NSMutableParagraphStyle { Alignment = UITextAlignment.Center },
            };

            string text;
            string[] splitFrom = From.Split(' ');
            if (splitFrom.Length > 1) {
                text = splitFrom[0][0].ToString() + splitFrom[1][0];
            } else if (splitFrom.Length > 0) {
                text = splitFrom[0][0].ToString();
            } else {
                text = "?";
            }

            NSString str = new NSString(text);

            var textSize = str.GetSizeUsingAttributes(textAttributes);
            str.DrawString(new CGRect(0, height/2 - textSize.Height/2, 
                width, height), textAttributes);

            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return image;
        }
    }
}

