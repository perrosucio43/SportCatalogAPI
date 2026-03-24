using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskManager.Domain.constants;
using TaskManager.Domain.Exceptions;
using TaskManager.Domain.ObjectsValues;
namespace TaskManager.Domain.Entities
{
   public class User
    {

        private const int MaxNameLenght= 150;
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Email Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string Role { get; private set; }

        private User() { }

        public User(string name, Email email, string passwordhash, string role) { 
        
        
        Id=Guid.NewGuid();
            ChangeName(name);
            Email=email;
            PasswordHash=passwordhash;
            Role = role ?? Roles.Customer;
            
           
        
        
        
        
        
        
        }
        
       
        public void ChangeName(string name) {

            if (string.IsNullOrWhiteSpace(name)) throw new DomainException("Name cannot be empty");
            if (name.Length > MaxNameLenght) throw new DomainException("Name cannot exceed 150 Characters.");

            Name = name.Trim().ToLowerInvariant();
        }

        public void ChangeEmail(Email email) {


            Email = email ?? throw new DomainException($"Email cannot be null.{email}");
        



        }
      
    }
}
