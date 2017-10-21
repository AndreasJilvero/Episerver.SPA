import React, { Component } from 'react';

class StringComponent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      propertyName: this.props.propertyName,
      value: this.props.value
    }
  }

  render() {
    return (
      <div data-epi-property-name={this.state.propertyName} data-epi-property-edittype="floating" data-epi-property-render="none">
        {this.state.value}
      </div>
    );
  }

  componentDidMount() {
    if (window.epi) {
      var epi = window.epi;
      epi.subscribe("beta/contentSaved", function (propertyDetails) {
        // Check if it was "our" property that changed
        if (this.props.propertyName.toUpperCase() === propertyDetails.properties[0].name.toUpperCase()) {
          this.setState({ value: propertyDetails.properties[0].value }); // Update this component's state to reflect the new property value in the UI
        }
      }.bind(this));
    }
  }
}

export default StringComponent;