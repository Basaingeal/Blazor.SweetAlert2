const path = require('path');

module.exports = {
  entry: './src/SweetAlert.ts',
  output: {
    filename: '[name].bundle.js',
    path: path.resolve(__dirname, 'content')
  },
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: 'ts-loader',
        exclude: /node_modules/
      }
    ]
  },
  resolve: {
    extensions: ['.tsx', '.ts', '.js']
  },
  devtool: 'inline-source-map',
  optimization: {
    splitChunks: {
      chunks: 'all'
      },
      minimize: false
  }
};