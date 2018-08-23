const path = require("path");
const fableUtils = require("fable-utils");

function resolve(relativePath) {
    return path.join(__dirname, relativePath);
}

module.exports = {
    entry: resolve("../tests/Tests.fsproj"),
    outDir: resolve("../test"),
    babel: fableUtils.resolveBabelOptions({
        presets: [["env", {
            modules: "commonjs",
            targets: { "node": "current" }
        }]],
        sourceMaps: true,
    }),
    fable: {
        define: ["DEBUG"]
    }
}
