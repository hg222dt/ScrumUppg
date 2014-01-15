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

        //Egenskap för medlems förnamn
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

        //Egenskap för medlems efternamn
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

        //Egenskap för medlems telefonnummer
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

        //Egenskap för medlems medlemsnummer
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
