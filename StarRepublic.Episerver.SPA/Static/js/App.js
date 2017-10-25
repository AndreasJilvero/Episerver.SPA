import React, { Component } from 'react';
import { Redirect } from 'react-router';
import StartPageComponent from './StartPageComponent';
import ContentPageComponent from './ContentPageComponent';
import {
  BrowserRouter as Router,
  Route,
  Link
} from 'react-router-dom'

const components = {
	"StartPage": StartPageComponent,
	"ContentPage": ContentPageComponent
};

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      menu: []
    };
  }

  componentWillMount() {
  	fetch("/api/tree")
		  .then(response => response.json())
      .then(json => {
        this.setState({
          menu: json
        });
      });
  }

	determineComponent = (props) => {
		let menuItem = this.state.menu.filter(item => item.url == props.location.pathname)[0];
		const PageComponent = components[menuItem.type];
		return <PageComponent contentReference={menuItem.contentReference} />
	}

  render() {
    return (
	    <Router>
	      <div>
	        <ul>
	          {this.state.menu.map((item, i) =>
	            <li key={i}><Link to={item.url}>{item.name}</Link></li>
	          )}
	        </ul>

					{this.state.menu.map((item, i) =>
	        	<Route path={item.url} exact component={this.determineComponent} key={i} />
	        )}

	        {/*{(window.parent && window.parent.epi) &&
						<Redirect to="/" />
					}*/}
	      </div>
	    </Router>
    );
  }
}

export default App;