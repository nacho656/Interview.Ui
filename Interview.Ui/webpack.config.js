const path = require('path');
const webpack = require('webpack');

const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const { VueLoaderPlugin } = require('vue-loader');
const TerserJSPlugin = require('terser-webpack-plugin');

module.exports = {
    entry: {
        'media.index': './Javascript/Media/media.index.js'
    },
    mode: "development",
    devtool: "inline-source-map",
    output: {
        path: path.resolve(__dirname, "wwwroot/dist"),
        filename: "[name].min.js",
        chunkFilename: "[name].min.js?cb=[chunkhash]",
        publicPath: '/dist/'
    },
    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: "vue-loader",
                options: {

                }
            }
        ]
    },
    resolve: {
        extensions: [".js"],
        alias: {
            "vue": "vue/dist/vue.esm-bundler.js"
        },
        modules: [path.resolve(__dirname,"Javascript"), 'node_modules']
    },
    optimization: {
        minimize: true,
        splitChunks: {
            cacheGroups: {
                vendors: {
                    test: /[\\/](vendor|node_modules)[\\/](?=.*\.js$)/,
                    name: 'vendor',
                    chunks: "all",
                }
            }
        }
    },
    plugins: [
        new VueLoaderPlugin(),
        new CleanWebpackPlugin({
            cleanOnceBeforeBuildPatterns: ["*.min.js", "*.js.map"]
        }),
        new TerserJSPlugin({ extractComments: false}),
        new webpack.DefinePlugin({
            __VUE_OPTIONS_API__: true,
            __VUE_PROD_DEVTOOLS__: false
        })
    ]
}