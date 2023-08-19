﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Extend
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAgree { get; set; }
    }
}
