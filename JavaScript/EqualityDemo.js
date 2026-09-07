function compareValues(a, b) {
    return {
        looseEquality: a == b,
        strictEquality: a === b
    }
}

function printResults(a, b) {
    const results = compareValues(a, b);
    console.log(`Comparing ${a} and ${b}:`);
    console.log(`  Loose Equality (==): ${results.looseEquality}`);
    console.log(`  Strict Equality (===): ${results.strictEquality}`);
    console.log('-----------------------------------');
}

console.log("Equality Comparison Demo");
printResults(5, '5');
printResults(0, false);
printResults(null, undefined);
printResults([], '');
printResults({}, {});
printResults(NaN, NaN);
printResults(1, true);
