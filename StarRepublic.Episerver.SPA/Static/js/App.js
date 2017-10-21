import React, { Component } from 'react';
import StringComponent from './StringComponent';
import {
  BrowserRouter as Router,
  Route,
  Link
} from 'react-router-dom'

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      menu: [],
      properties: []
    };
  }

  componentWillMount() {
  	fetch("/api/tree")
		  .then(response => response.json())
      .then(json => {
        console.log(json);
        this.setState({
          menu: json
        });
      });

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
      <Router>
        <div>
          <ul>
            {this.state.menu.map((item, i) =>
              <li key={i}><Link to={item.url}>{item.name}</Link></li>
            )}
          </ul>

          {this.state.menu.map((item, i) =>
            <Route path={item.url} render={() => <div>Home</div>} key={i} />
          )}
        </div>
      </Router>

      {this.state.properties.map((item, i) =>
        <StringComponent key={i} {...item} />
      )}
	   </div>
    );
  }
}

export default App;