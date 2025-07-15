var file = File.ReadAllText(args[0]);

var dict = new Dictionary<char, int>();

var stripped = new string(file.Where(x => !char.IsAsciiLetter(x)).ToArray());

foreach(var c in stripped) {
    if(dict.ContainsKey(c)) {
        dict[c]++;
        continue;
    }
    dict.Add(c, 0);
}

var ordered = dict.ToList().OrderBy(x => x.Value).ToList();

foreach(var entry in ordered) {
    Console.WriteLine($"'{entry.Key}', {entry.Value}");
}
