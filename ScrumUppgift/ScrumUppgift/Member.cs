using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumUppgift
{
    class Member
    {
        private string firstName;

        private string lastName;

        private int phoneNumber;

        private int memberNumber;

        public string _firstName
        {
            get 
            { 
                return firstName; 
            }

            set
            {
                firstName = value;
            }
        }

        public string _lastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public int _phoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }

        public int _memberNumber
        {
            get
            {
                return memberNumber;
            }

            set
            {
                memberNumber = value;
            }
        }
    }
}
