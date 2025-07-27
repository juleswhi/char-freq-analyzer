var file = File.ReadAllText(args[0]);

int KB_WIDTH = 10;

int[] keys = [
    3, 2, 1, 2, 2,    2, 2, 2, 2, 3,
    1, 1, 1, 0, 1,    1, 0, 0, 1, 1,
    4, 3, 2, 2, 2,    2, 2, 3, 3, 4,
];

var dict = new Dictionary<char, int>();

var stripped = new string(file.Where(x => !char.IsAsciiLetter(x) && !char.IsWhiteSpace(x) && !char.IsDigit(x)).ToArray());

foreach(var c in stripped) {
    if(dict.ContainsKey(c)) {
        dict[c]++;
        continue;
    }
    dict.Add(c, 0);
}

var ordered = dict.ToList().OrderBy(x => -x.Value).ToList();

var char_freq = ordered.Select(x => x.Key).ToList();

var sorted_pos = keys.Select((ergo, idx) => (ergo, idx))
    .OrderBy(x => x.ergo)
    .Select(x => x.idx)
    .ToList();

var layout = new char[keys.Length];
int count = Math.Min(char_freq.Count(), sorted_pos.Count());

for(int i = 0; i < count; i++) {
    layout[sorted_pos[i]] = char_freq[i];
}

string horiz_border = Enumerable.Repeat('-', KB_WIDTH * 4).Select(x => x.ToString()).Aggregate((x, y) => $"{x}{y}");

Console.WriteLine(horiz_border);

for (int i = 0; i < layout.Length; i++)
{
    if (i % KB_WIDTH == 0) Console.Write("|");
    var c = layout[i] == '\0' ? ' ' : layout[i];
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write($"{c}");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" | ");
    if (i % KB_WIDTH == KB_WIDTH - 1) {  Console.WriteLine(); Console.WriteLine(horiz_border); }
}

