// https://www.reddit.com/r/adventofcode/comments/3vr4m4/day_7_solutions/cxq5gd3
var str = document.body.innerText;

var wires = {};
function Wire(instruction) {
    this.calculate = this.generateValueGetter(instruction);
}

Wire.prototype.getValue = function () {
    if (this.value === undefined) {
        this.value = this.checkRange(this.calculate());
    }
    return this.value;
};

Wire.prototype.checkRange = function (i) {
    var n = 65536;
    return ((i % n) + n) % n;
};

Wire.prototype.generateValueGetter = function (instruction) {
    var assignMatch, opMatch;

    if (assignMatch = /^(NOT )?([0-9]+|[a-z]+)$/.exec(instruction)) {
        return function () {
            var value = parseValue(assignMatch[2]);
            if (assignMatch[1])
                value = ~value;
            return value;
        }
    } else if (opMatch = /^([a-z]+|[0-9]+) (AND|OR|LSHIFT|RSHIFT) ([a-z]+|[0-9]+)$/.exec(instruction)) {
        var opCode = this.ops[opMatch[2]];

        return function () {
            return eval(parseValue(opMatch[1]) + ' ' + opCode + ' ' + parseValue(opMatch[3]));
        }

    }
};

Wire.prototype.ops = {
    'AND': '&',
    'OR': '|',
    'LSHIFT': '<<',
    'RSHIFT': '>>',
};

// Determine if a key refers to an integer or a wire & return its value
function parseValue(key) {
    var i = parseInt(key);
    return !isNaN(i) ? i : wires[key].getValue();
}

// Generate all wire objects
str.split('\n').forEach(function (item) {
    var match;
    if (match = /(.*) -> ([a-z]+)/.exec(item))
        wires[match[2]] = new Wire(match[1]);
});

// Output Part One Answer
var partOne = wires.a.getValue();
console.log('Part One:', partOne);

// Reset for Part Two
Object.keys(wires).forEach(function (key) {
    wires[key].value = undefined;
});
wires.b.value = partOne;

// Output Part Two Answer
console.log('Part Two:', wires.a.getValue());