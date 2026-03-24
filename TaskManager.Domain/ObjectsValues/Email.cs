using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskManager.Domain.Exceptions;

namespace TaskManager.Domain.ObjectsValues
{
    public sealed class Email : IEquatable<Email>
    {

        private readonly static Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private const int MaxLength = 255;

        public string Value { get; }

        private Email(string value)
        {

            Value = value;
        }
        private Email() { }

        public static Email Create(string input)
        {


            if (string.IsNullOrWhiteSpace(input)) throw new DomainException("Email cannot be Empty.");

            var normalized = input.Trim().ToLowerInvariant();


            if (normalized.Length > MaxLength) throw new DomainException($"Email cannot exceed {MaxLength} characters");

            if (!EmailRegex.IsMatch(normalized)) throw new DomainException($"Format is invalid {input}");

            return new Email(normalized);

        }

        public override string ToString() { return Value; }

        public override bool Equals(object? obj)=>obj is Email other && Equals(other);
       

        public bool Equals(Email? other)
        {

           return other is not null && Value==other.Value;

        }


        public override int GetHashCode() { return Value.GetHashCode(); }

        public static bool operator == (Email? left, Email? right)
        {
            if(ReferenceEquals(left, null) && ReferenceEquals(right, null)) return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;

            if (ReferenceEquals(left, right)) return true;

            return left.Equals(right);
        }

        public static bool operator !=(Email? left, Email? right) {


            return !(left == right);
        
        
        
        
        }
    }
   
}
