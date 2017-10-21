const path = require('path');

module.exports = {
  entry: './Static/js/index.js',
  output: {
    filename: 'bundle.js',
    path: path.resolve(__dirname, 'Static')
  },
  module: {
    loaders: [
      {
        test: /\.js$/,
        exclude: /node_modules/,
        loader: "babel-loader",
        query: {
          presets: ['react', 'env'] 
        }
      }
    ]
  }
};