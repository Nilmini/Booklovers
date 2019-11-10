using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Booklovers.Data;
using System;
using System.Linq;
using NLog.Web;
using NLog;

namespace Booklovers.Models
{
    public static class SeedData
    {
        private static Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookloverBookContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BookloverBookContext>>()))
            {
                DateTime currentTime = DateTime.Now;

                // Look for any data availability. If not add data to the table
                if (!context.Author.Any())
                {
                    logger.Debug("Seeding authors data");
                    context.Author.AddRange(
                        new Author
                        {
                            Name = "Robert T. Kiyosaki",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/31H4fUBky1L._US230_.jpg",
                            Bio = "Robert Kiyosaki, author of Rich Dad Poor Dad - the international runaway bestseller that has held a top spot on the New York Times bestsellers list for over six years - is an investor, entrepreneur and educator whose perspectives on money and investing fly in the face of conventional wisdom.",
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        },
                        new Author
                        {
                            Name = "Delia Owens",
                            ImageUrl = "https://i2.wp.com/www.mysterytribune.com/wp-content/uploads/2019/01/Delia-Owens-Profile-Of-Where-the-Crawdads-Sing-Author.jpg?fit=770%2C954&ssl=1",
                            Bio = "Delia Owens is an American author and zoologist. Her debut novel Where the Crawdads Sing topped The New York Times Fiction Best Sellers of 2019 for several weeks. The book has been on the New York Times Bestsellers list for more than a year.",
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        },
                        new Author
                        {
                            Name = "Dalai Lama",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/31vccKBNfgL._US230_.jpg",
                            Bio = "His Holiness the Fourteenth Dalai Lama, Tenzin Gyatso, was born in 1935 to a peasant family in northeastern Tibet and was recognized at the age of two as the reincarnation of his predecessor, the Thirteenth Dalai Lama.",
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        },
                        new Author
                        {
                            Name = "Michelle Obama",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/81gqDyw-wvL._US230_.jpg",
                            Bio = "Michelle Robinson Obama served as First Lady of the United States from 2009 to 2017. A graduate of Princeton University and Harvard Law School, Mrs. Obama started her career as an attorney at the Chicago law firm Sidley & Austin, where she met her future husband, Barack Obama. ",
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        },
                        new Author
                        {
                            Name = "David Allen",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41qA2b-WslL._US230_.jpg",
                            Bio = "David Allen is widely recognized as the world's leading expert on personal and organizational productivity. His thirty-year pioneering research and coaching to corporate managers and CEOs of some of America's most prestigious corporations and institutions has earned him Forbes' recognition as one of the top five executive coaches in the U.S. and Business 2.0 magazine's inclusion in their 2006 list of the '50 Who Matter Now.'",
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        },
                        new Author
                        {
                            Name = "J. K. Rowling",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/amzn-author-media-prod/fvh43djng407r1iq142ng0sk5f._US230_.jpg",
                            Bio = "J.K. Rowling is the author of the record-breaking, multi-award-winning Harry Potter novels. Loved by fans around the world, the series has sold more than 500 million copies, been translated into 80 languages and made into eight blockbuster films.",
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        },
                        new Author
                        {
                            Name = "Simon Sinek",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51yMIHz8PSL._US230_.jpg",
                            Bio = "Simon Sinek is an optimist. He teaches leaders and organizations how to inspire people. From members of Congress to foreign ambassadors, from small businesses to corporations like Microsoft and 3M, from Hollywood to the Pentagon, he has presented his ideas about the power of why.",
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }


                    );
                    context.SaveChanges();
                }
                if (!context.Book.Any())
                {
                    logger.Debug("Seeding books data");
                    context.Book.AddRange(
                        new Book
                        {
                            Title = "Where the Crawdads Sing",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/51qtXBoiv8L.jpg",
                            AuthorId = 2,
                            Price = 13,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        },
                        new Book
                        {
                            Title = "The Book of Joy: Lasting Happiness in a Changing World",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/91XrIUJA9aL.jpg",
                            AuthorId = 3,
                            Price = 9,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Becoming",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/81h2gWPTYJL.jpg",
                            AuthorId = 4,
                            Price = 13,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Rich Dad Poor Dad",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/91VokXkn8hL.jpg",
                            AuthorId = 1,
                            Price = 13,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Rich Dad's CASHFLOW Quadrant: Rich Dad's Guide to Financial Freedom",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/41aJnFuCBWL.jpg",
                            AuthorId = 1,
                            Price = 12,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Rich Dad's Guide to Investing",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/916O61iZWVL.jpg",
                            AuthorId = 1,
                            Price = 11,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Getting Things Done: The Art of Stress-Free Productivity",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/51bGhYfO9KL._SX342_.jpg",
                            AuthorId = 5,
                            Price = 14,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Making It All Work: Winning at the game of work and the business of life",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/51BVTXhMgKL.jpg",
                            AuthorId = 5,
                            Price = 9,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Harry Potter and the Goblet of Fire: The Illustrated Edition",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/61Me3ePpM9L._SX421_BO1,204,203,200_.jpg",
                            AuthorId = 6,
                            Price = 13,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Harry Potter and the Chamber of Secrets",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/51OihdkhSBL._SX329_BO1,204,203,200_.jpg",
                            AuthorId = 6,
                            Price = 15,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Harry Potter and the Sorcerer's Stone",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/51HSkTKlauL._SX346_BO1,204,203,200_.jpg",
                            AuthorId = 6,
                            Price = 13,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Start with Why: How Great Leaders Inspire Everyone to Take Action",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/71QUhm-AnIL.jpg",
                            AuthorId = 7,
                            Price = 13,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "The Infinite Game",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/41xC6fNkf2L._SX294_BO1,204,203,200_.jpg",
                            AuthorId = 7,
                            Price = 8,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Leaders Eat Last: Why Some Teams Pull Together and Others Don't",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/518JdacNycL._SX330_BO1,204,203,200_.jpg",
                            AuthorId = 7,
                            Price = 13,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "The Art of Happiness, 10th Anniversary Edition: A Handbook for Living",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/71zNTPjajaL.jpg",
                            AuthorId = 3,
                            Price = 13,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Beyond Religion: Ethics for a Whole World",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/51-W1m2z4WL.jpg",
                            AuthorId = 3,
                            Price = 11,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "The Dalai Lama's Cat",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/41BsepZU24L.jpg",
                            AuthorId = 3,
                            Price = 18,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "The Tales of Beedle the Bard: The Illustrated Edition (Harry Potter)",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/71Nav-k%2B71L.jpg",
                            AuthorId = 6,
                            Price = 16,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Harry Potter Paperback Box Set (Books 1-7)",
                            Thumbnail = "",
                            AuthorId = 6,
                            Price = 52,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                        ,
                        new Book
                        {
                            Title = "Rich Dad's Increase Your Financial IQ: Get Smarter with Your Money",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/514j-05vuZL._SX342_.jpg",
                            AuthorId = 1,
                            Price = 13,
                            CreatedTime = currentTime,
                            ModifiedTime = currentTime
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}