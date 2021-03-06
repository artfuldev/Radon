﻿using System.Collections.Generic;

namespace Radon.UriTemplates.Tests
{
    public class TestCase
    {
        public string Template { get; set; }

        public List<string> Expecteds { get; set; }

        public bool IsInvalid { get; set; }

        public TestSuite Suite { get; set; }

        public override string ToString()
        {
            return "\"" + Template + "\"";
        }
    }
}