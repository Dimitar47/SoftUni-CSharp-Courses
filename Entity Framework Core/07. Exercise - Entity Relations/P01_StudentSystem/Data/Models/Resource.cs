﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {

     
        public int ResourceId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; } 

        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
    public enum ResourceType
    {
        Video, Presentation, Document , Other

    }
}
