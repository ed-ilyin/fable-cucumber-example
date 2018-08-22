var CONFIG = {
    fsharpEntry: "./tests/Tests.fsproj",
    outputDir: "../test",
    babel: {
        presets: [
            ["env", {
                "modules": false,
                "useBuiltIns": true,
                "targets": { "node": "current" }
            }]
        ],
    }
}
var path = require("path");
module.exports = {
    entry: { tests: ["core-js", CONFIG.fsharpEntry] },
    output: {
        path: path.join(__dirname, CONFIG.outputDir),
        filename: '[name].js'
    },
    mode: "development",
    devtool: "eval-source-map",
    resolve: { symlinks: false },
    module: {
        rules: [
            {
                test: /\.fs(x|proj)?$/,
                use: "fable-loader"
            },
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: CONFIG.babel
                },
            }
        ]
    }
};
