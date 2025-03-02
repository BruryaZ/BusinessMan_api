﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessMan.Core.Models
{
    public class User
    {
        public int Id { get; set; } // מזהה ייחודי
        public string FirstName { get; set; } // שם פרטי
        public string LastName { get; set; } // שם משפחה
        public string Email { get; set; } // אימייל
        public string Password { get; set; } // סיסמה (מוצפנת)
        public string Phone { get; set; } // מספר פלאפון
        public int Role { get; set; } // תפקיד עובד (admin / user) // 1 = admin, 2 = user, 3 = bookkeeper
        public string IdNumber { get; set; } // תעודת זהות
        public string Status { get; set; } = "active"; // מצב המשתמש (active/inactive)
        public DateTime LastLogin { get; set; } = DateTime.Now; // תאריך כניסה אחרונה
        public DateTime CreatedAt { get; set; } = DateTime.Now; // תאריך יצירה
        public string CreatedBy { get; set; } // נוצר על ידי
        public DateTime UpdatedAt { get; set; } = DateTime.Now; // תאריך עדכון
        public string UpdatedBy { get; set; } // עודכן על ידי

        // אובייקטים לקשרים בין הטבלאות
        public Business Business { get; set; }
        public List<Invoice> Invoices { get; set; }
        public int BusinessId { get; set; } // מזהה ייחודי לעסק
    }
}