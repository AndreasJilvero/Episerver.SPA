import React, { Component } from 'react';
import StringComponent from './StringComponent';

class StartPageComponent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      title: null
    }
  }

  componentWillMount() {
    fetch("/api/content?contentId=" + this.props.contentReference)
      .then(response => response.json())
      .then(json => {
        this.setState({
          title: json['title']
        });
      });
  }

  render() {
    return (
      <div>
        <StringComponent propertyName="title" value={this.state.title} changeValue={(value) => { this.setState({ title: value }) }} />
      </div>
    );
  }

  componentDidMount() {
    {/*document.addEventListener("DOMContentLoaded", function(event) {
      setTimeout(function() {
        if (window.parent && window.parent.require) {
          var on = window.parent.require("dojo/on");
          var iframe = window.parent.document.getElementsByTagName("iframe")[0];
          on.emit(iframe, "load", {
            bubbles: true,
            cancelable: true
          });
        }
      }, 2000);
    });*/}
  }
}

export default StartPageComponent;