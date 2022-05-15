using System.IO.Ports;
using System.Linq;
using MeterTest.Source.SQLite;
using Microsoft.EntityFrameworkCore;

namespace MeterTest.Source.Dlt645
{
    public class Dlt645Server
    {
        public int Id;
        public long Address;
        public int Password;
        public byte Authority;
        public int OperatorCode;

        public MeterAddress MeterAddress
        {
            get
            {
                return new MeterAddress(Address);
            }
            set
            {
                Address = value.Address;
            }
        }
        public Dlt645Password Dlt645Password
        {
            get
            {
                return new Dlt645Password(Authority, Password);
            }
            set
            {
                Authority = value.Authority;
                Password  = value.Password;
            }
        }
        public Dlt645OperatorCode Dlt645OperatorCode
        {
            get
            {
                return new Dlt645OperatorCode(OperatorCode);
            }
            set
            {
                OperatorCode = value.OperatorCode;
            }
        }
        public Dlt645Server()
        {
            MeterAddress = MeterAddress.Wildcard;
            Dlt645Password = new Dlt645Password();
            Dlt645OperatorCode = new Dlt645OperatorCode();
        }
    }
}