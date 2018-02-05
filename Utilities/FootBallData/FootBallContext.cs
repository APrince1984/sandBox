﻿using System;
using FootBallData.Tables;
using System.Data.Entity;
using System.Configuration;

//using Microsoft.EntityFrameworkCore;

namespace FootBallData
{
    public class FootBallContext : DbContext
    {
        public FootBallContext() : base(ConfigurationManager.ConnectionStrings["FootBallContext"].ConnectionString)
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Title> Titles { get; set; }
    }
}
