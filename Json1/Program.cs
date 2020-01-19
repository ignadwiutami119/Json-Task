using System;
// using System.Text.Json;
// using System.Text.Json.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Json_Task
{
    class Program
    {
        static void Main(string[] args)
        {

            json obj = new json();

            var ObjekList = JsonConvert.DeserializeObject<List<objek>>(obj.jsonformat);

            System.Console.WriteLine();
            System.Console.WriteLine("--- DESERIALIZED FIRST JSON FORMAT ---");
            System.Console.WriteLine();

            Console.WriteLine("User who doesn't have any phone number :");
            foreach (var a in ObjekList)
            {
                if ((a.profile.Phones).Count == 0)
                    Console.WriteLine("- " + a.profile.Fullname);
            }

            Console.WriteLine();
            Console.WriteLine("User who have article :");
            foreach (var a in ObjekList)
            {
                if ((a.Id) != 0)
                    Console.WriteLine("- " + a.profile.Fullname);
            }

            Console.WriteLine();
            Console.WriteLine("User who have annis in their name :");
            foreach (var b in ObjekList)
            {
                if ((b.profile.Fullname).Contains("Annis"))
                    Console.WriteLine("- " + b.profile.Fullname);
            }

            Console.WriteLine();
            Console.WriteLine("User who have articles on year 2020 :");
            if (Article2020() == "")
            {
                Console.WriteLine("** No one have article on 2020 **");
            }
            else
            {
                Console.WriteLine(Article2020());
            }

            Console.WriteLine();
            Console.WriteLine("User who are born on 1986 :");
            foreach (var b in ObjekList)
            {
                if (Convert.ToString((b.profile.BirthDay)).Contains("1986"))
                {
                    Console.WriteLine("- " + b.Username);
                }

            }

            Console.WriteLine();
            Console.WriteLine("Articles that contain Tips on the title :");
            foreach (var d in ObjekList)
            {
                foreach (var item in d.ArticleList)
                    if ((item.Title).Contains("Tips"))
                    {
                        Console.WriteLine("- " + item.Title);
                    }
                    else
                    {
                        break;
                    }
            }

            Console.WriteLine();
            Console.WriteLine("Article that published before August 2019 :");
            if (publishBefore() == "")
            {
                System.Console.WriteLine("No article published before August 2019");
            }
            else
            {
                System.Console.WriteLine(publishBefore());
            }

            string publishBefore()
            {
                int year;
                int month;
                int number = 0;
                string hasil = "";
                foreach (var b in ObjekList)
                {
                    foreach (var item in b.ArticleList)
                    {
                        year = (item.Published).Year;
                        month = (item.Published).Month;
                        if (year == 2019 && month < 8)
                        {
                            number++;
                            hasil += number + ". " + item.Title + "\n";
                        }
                    }
                }
                return hasil;
            }

            string Article2020()
            {
                int year;
                string hasil = "";
                int number = 0;
                foreach (var b in ObjekList)
                {
                    foreach (var item in b.ArticleList)
                    {
                        year = (item.Published).Year;
                        if (year == 2020)
                        {
                            number++;
                            hasil += number + ". " + b.Username + "\n";
                        }
                    }
                }
                return hasil;
            }

        }
    }

    public class json
    {
        public string jsonformat = @"[{
                                ""id"": 323,
                                ""username"": ""rinood30"",
                                ""profile"": {
                                ""full_name"": ""Shabrina Fauzan"",
                                ""birthday"": ""1988-10-30"",
                                ""phones"": [
                                    ""08133473821"",
                                    ""082539163912"",
                                ],
                                },
                                ""articles"": [
                                {
                                    ""id"": 3,
                                    ""title"": ""Tips Berbagi Makanan"",
                                    ""published_at"": ""2019-01-03T16:00:00""
                                },
                                {
                                    ""id"": 7,
                                    ""title"": ""Cara Membakar Ikan"",
                                    ""published_at"": ""2019-01-07T14:00:00""
                                }
                                ]
                            },
                            {
                                ""id"": 201,
                                ""username"": ""norisa"",
                                ""profile"": {
                                ""full_name"": ""Noor Annisa"",
                                ""birthday"": ""1986-08-14"",
                                ""phones"": [],
                                },
                                ""articles"": [
                                {
                                    ""id"": 82,
                                    ""title"": ""Cara Membuat Kue Kering"",
                                    ""published_at"": ""2019-10-08T11:00:00""
                                },
                                {
                                    ""id"": 91,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-11-11T13:00:00""
                                },
                                {
                                    ""id"": 31,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-11-11T13:00:00""
                                }
                                ]
                            },
                            {
                                ""id"": 42,
                                ""username"": ""karina"",
                                ""profile"": {
                                ""full_name"": ""Karina Triandini"",
                                ""birthday"": ""1986-04-14"",
                                ""phones"": [
                                    ""06133929341""
                                ],
                                },
                                ""articles"": []
                            },
                            {
                                ""id"": 201,
                                ""username"": ""icha"",
                                ""profile"": {
                                ""full_name"": ""Annisa Rachmawaty"",
                                ""birthday"": ""1987-12-30"",
                                ""phones"": [],
                                },
                                ""articles"": [
                                {
                                    ""id"": 39,
                                    ""title"": ""Tips Berbelanja Bulan Tua"",
                                    ""published_at"": ""2019-04-06T07:00:00""
                                },
                                {
                                    ""id"": 43,
                                    ""title"": ""Cara Memilih Permainan di Steam"",
                                    ""published_at"": ""2019-06-11T05:00:00""
                                },
                                {
                                    ""id"": 58,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-09-12T04:00:00""
                                }
                                ]
                            }]";
    }

    class profile
    {
        [JsonProperty("full_name")]
        public string Fullname { get; set; }

        [JsonProperty("birthday")]
        public DateTime BirthDay { get; set; }

        [JsonProperty("phones")]
        public List<string> Phones { get; set; } = new List<string>();
    }

    class articles
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("published_at")]
        public DateTime Published { get; set; }
    }

    class objek
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("profile")]
        public profile profile { get; set; } = new profile();

        [JsonProperty("articles")]
        public List<articles> ArticleList { get; set; } = new List<articles>();
    }
}