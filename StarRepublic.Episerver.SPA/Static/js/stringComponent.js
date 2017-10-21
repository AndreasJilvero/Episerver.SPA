import React, { Component } from 'react';

class StringComponent extends Component {
  constructor(props) {
    super(props);

    console.log(props);
    console.log(window.epi);
  }

  render() {
    let {
        propertyName,
        value
    } = this.props;

    return (
      <div>
        <span data-epi-property-name={propertyName} data-epi-property-edittype="floating" data-epi-property-render="none">{value}</span>
      </div>
    );
  }
}

export default StringComponent;