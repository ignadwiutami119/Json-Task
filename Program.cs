using System;
// using System.Text.Json;
// using System.Text.Json.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Json_Task {
    class Program {
        static void Main (string[] args) {

            json obj = new json ();

            var ProfileList = JsonConvert.DeserializeObject<List<user>> (obj.jsonformat);
            var ArticleList = JsonConvert.DeserializeObject<List<articles>> (obj.jsonformat);

            Console.WriteLine ("user who doesn't have any phone number :");
            foreach (var a in ProfileList) {
                if ((a.profile.Phones).Count == 0)
                    Console.WriteLine (a.Username);
            }

            Console.WriteLine ();
            Console.WriteLine ("user who have article :");
            foreach (var a in ArticleList) {
                if ((a.Id) != 0)
                    Console.WriteLine (a.Id);
            }

            Console.WriteLine ();
            Console.WriteLine ("user who have annis in their name :");
            foreach (var b in ProfileList) {
                if ((b.profile.Fullname).Contains ("Annis"))
                    Console.WriteLine (b.Username);
            }

            Console.WriteLine ();
            Console.WriteLine ("user who have articles on year 2020 :");
            foreach (var b in ArticleList) {
                if (Convert.ToString ((b.Published)).Contains ("2019")) {
                    Console.WriteLine (b.Id);
                } else {
                    Console.WriteLine ("no one publishing article on 2020");
                    break;
                }
            }

            Console.WriteLine ();
            Console.WriteLine ("user who are born on 1986 :");
            foreach (var b in ProfileList) {
                if (Convert.ToString ((b.profile.BirthDay)).Contains ("1986")) {
                    Console.WriteLine (b.Username);
                }
            }
        }
    }

    public class json {
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

    class profile {
        [JsonProperty ("full_name")]
        public string Fullname { get; set; }

        [JsonProperty ("birthday")]
        public DateTime BirthDay { get; set; }

        [JsonProperty ("phones")]
        public List<string> Phones { get; set; } = new List<string> ();
    }

    class articles {
        [JsonProperty ("id")]
        public int Id { get; set; } = 0;

        [JsonProperty ("title")]
        public string Title { get; set; }

        [JsonProperty ("published_at")]
        public DateTime Published { get; set; }
    }

    class user {
        [JsonProperty ("username")]
        public string Username { get; set; }

        [JsonProperty ("article")]
        public articles articles { get; set; }

        [JsonProperty ("profile")]
        public profile profile { get; set; }

        [JsonProperty ("id")]
        public int Id { get; set; }
    }
}