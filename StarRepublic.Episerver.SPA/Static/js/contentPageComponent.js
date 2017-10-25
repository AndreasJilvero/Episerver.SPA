import React, { Component } from 'react';
import StringComponent from './StringComponent';

class ContentPageComponent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      content: null
    }
  }

  componentWillMount() {
    fetch("/api/content?contentId=" + this.props.contentReference)
      .then(response => response.json())
      .then(json => {
        this.setState({
          content: json['content']
        });
      });
  }

  render() {
    return (
      <div>
        <StringComponent propertyName="content" value={this.state.content} changeValue={(value) => { this.setState({ content: value }) }} />
      </div>
    );
  }

  componentDidMount() {
    {/*setTimeout(function() {
      if (window.parent && window.parent.require) {
        var iframe = window.parent.require("epi/shell/widget/Iframe");
        iframe().reload()
          .then(function(e) {
            console.log(e);
          }, function(err) {
            console.error(err);
          });

        var on = window.parent.require("dojo/on");
        var iframe = window.parent.document.getElementsByTagName("iframe")[0];
        on.emit(iframe, "load", {
          bubbles: true,
          cancelable: true
        });
      }
    }, 500);*/}
  }
}

export default ContentPageComponent;