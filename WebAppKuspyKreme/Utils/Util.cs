using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppKuspyKreme.Models;

namespace WebAppKuspyKreme.Utils
{
    public static class Util
    {
        static Random rnd = new Random();
        static char[] letters = "abcdefghigklmnopqrstuvwxyz".ToArray();
        static string output;

        public static string GenerateGuid(int NoOfLetter)
        {
            output = null;
            for (int i = 0; i < NoOfLetter; i++)
            {
                output += letters[rnd.Next(0, letters.Length)];
            }

            return output.ToUpper();
        }

        public static List<Establishment> GetEstablishments()
        {
            List<Establishment> establishments = new List<Establishment>()
            {
                new Establishment()
                {
                    
                    Id = 1,
                    Name = "ESTABLISHMENT 1"
                },
                new Establishment
                {
                    Id = 2,
                    Name = "ESTABLISHMENT 2"
                },
                new Establishment
                {
                    Id = 3,
                    Name = "ESTABLISHMENT 3"
                }
            };

            return establishments;
        }

        public static List<Status> GetEstatus()
        {
            List<Status> Status = new List<Status>()
            {
                new Status()
                {
                    Id = 1,
                    Name = "DISPONIBLE"
                },
                new Status
                {
                     Id = 2,
                    Name = "CANJEADO"
                },
                new Status
                {
                     Id = 3,
                    Name = "VENCIDO"
                }
            };

            return Status;
        }
    }

    
}