import React, { Component } from 'react';

class StringComponent extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div data-epi-property-name={this.props.propertyName} data-epi-property-edittype="floating" data-epi-property-render="none">
        {this.props.value}
      </div>
    );
  }

  componentDidMount() {
    if (window.epi && window.epi.subscribe) {
      var epi = window.epi;

      epi.subscribe("beta/contentSaved", (propertyDetails) => {
         // Check if it was "our" property that changed
        if (this.props.propertyName.toUpperCase() === propertyDetails.properties[0].name.toUpperCase()) {
          this.props.changeValue(propertyDetails.properties[0].value);
        }
      });
    }
  }
}

export default StringComponent;