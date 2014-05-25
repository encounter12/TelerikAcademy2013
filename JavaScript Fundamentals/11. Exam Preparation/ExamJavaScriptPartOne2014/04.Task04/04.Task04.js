function Solve(n) {
    function factorial(n) {
        var fact = 1; for (k = 2; k <= n; k++) fact = fact * k;
        return fact;
    }
    return factorial(2 * n)/(factorial(n + 1)*factorial(n))/2;
}

console.log(Solve(7));