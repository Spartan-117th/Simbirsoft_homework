using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoFixture;
using TicTacToe;

namespace DatabaseTests.Providers
{
    public class MarkProviderFake : IMark               //Fake Mark provider
    {
        public string PlaceMark(string s)
        {
            var s_fake = new Fixture().Create<string>();

            return s_fake;          //not s
        }
    }
}
