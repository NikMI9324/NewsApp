﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Backend.User.Domain.Models
{
    public class Permission
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}
