//Практика «Тестирование»

public static void RunTests()
{
	Test("hello    world", new[] { "hello", "world" });
	Test("hello world", new[] { "hello", "world" });
	Test(string.Empty, new string[0]);
	Test("So", new[] {"So"});
	Test("\"w 'h' 'a' t\"", new[]{"w 'h' 'a' t"});
	Test(@"""\\""", new[] { "\\" }); 
	Test("i \"can say\" 'u y'",new[]{"i", "can say", "u y"} );
    Test("\"bcd ", new[]{"bcd "});
	Test(" Happy ", new[]{"Happy"});
    Test("a\"b\"", new[] {"a","b"});
    Test("\'a \"c\"\'", new[] {"a \"c\""});
	Test("\"New Year\"Santa", new[] {"New Year", "Santa"});
	Test(@"""""", new[] {""});
	Test(@"""the\""",new[] {"the\""});
	Test(@"'\'end\''", new[] {"\'end\'"});
}