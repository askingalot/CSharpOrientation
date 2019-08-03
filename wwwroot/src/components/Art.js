import React, { Component } from 'react';
import { Input, InputGroup, Button } from 'reactstrap';


export class Art extends Component {
  state = {
    art: [],
    loading: true,
    searchCriteria: ''
  };

  componentDidMount() {
    this.getArtTitles();
  }

  onInputChange = (evt) => {
    this.setState({ [evt.target.id]: evt.target.value });
  }

  doSearch = (evt) => {
    evt.preventDefault();
    this.getArtTitles();
  };

  getArtTitles = () => {
    this.setState({ loading: true });

    fetch(`api/ArtData/GetTitles/${this.state.searchCriteria}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ art: data, loading: false });
      });
  };

  renderForecastsTable = (artList) => {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Title</th>
            <th></th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {artList.map(art =>
            <tr key={art}>
              <td>{art}</td>
              <td></td>
              <td></td>
              <td></td>
            </tr>
          )}
        </tbody>
      </table>
    );
  };

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderForecastsTable(this.state.art);

    return (
      <div>
        <h1>Art Titles</h1>
        <InputGroup>
          <Input id="searchCriteria" onChange={this.onInputChange} />
          <Button onClick={this.doSearch}>Search</Button>
        </InputGroup>
        {contents}
      </div>
    );
  }
}
