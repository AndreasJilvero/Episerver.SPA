import React, { Component } from 'react';
import StringComponent from './StringComponent';

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      properties: []
    };
  }

  componentWillMount() {
    fetch("/api/content?contentId=5")
      .then(response => response.json())
      .then(json => {
        var arr = Object.keys(json).map(item => ({ propertyName: item, value: json[item] }));
        this.setState({
          properties: arr
        });
      });
  }

  render() {
    return (
     <div>
      {this.state.properties.map((item, i) =>
        <StringComponent key={i} {...item} />
      )}
	   </div>
    );
  }
}

export default App;