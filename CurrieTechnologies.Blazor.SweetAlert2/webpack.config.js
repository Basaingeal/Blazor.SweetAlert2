﻿const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const FileManagerPlugin = require('filemanager-webpack-plugin');
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');
const TerserJSPlugin = require('terser-webpack-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');

module.exports = {
  entry: {
    sweetAlert2: './src/ts/SweetAlert.ts',
    'sweetAlert2.min': './src/ts/SweetAlert.ts',
    'darkTheme.min': './src/scss/dark-theme.scss',
    'minimalTheme.min': './src/scss/minimal-theme.scss',
    'borderlessTheme.min': './src/scss/borderless-theme.scss'
  },
  output: {
    filename: "[name].js",
    path: path.resolve(__dirname, 'content')
  },
  module: {
    rules: [
      {
        test: /\.ts$/,
        use: 'ts-loader',
        exclude: /node_modules/
      },
      {
        test: /\.(sass|scss)$/,
        use: [
          MiniCssExtractPlugin.loader,
          "css-loader",
          "sass-loader"
        ],
        exclude: /node_modules/
      }
    ]
  },
  mode: 'production',
  plugins: [
    new FileManagerPlugin({
      onEnd: {
        delete: [
          path.resolve(__dirname, 'content', 'darkTheme.min.js'),
          path.resolve(__dirname, 'content', 'minimalTheme.min.js'),
          path.resolve(__dirname, 'content', 'borderlessTheme.min.js')
        ]
      }
    }),
    new MiniCssExtractPlugin({
      filename: "[name].css",
      path: path.resolve(__dirname, 'content')
    }),
    new CleanWebpackPlugin()
  ],
  optimization: {
    minimizer: [
      new TerserJSPlugin({
        include: /\.min\.js$/
      }),
      new OptimizeCSSAssetsPlugin({
        include: /\.min\.css$/
      })]
  }
};