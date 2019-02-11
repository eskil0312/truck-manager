import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import Layout from './Layout';
import RegisterFuel from './RegisterFuel';
import Dashboard from './Dashboard';

class App extends Component {
  render() {
    return (
      <Layout>
        <Switch>
          <Route path ='/register-fuel'  component={RegisterFuel}/>
          <Route path ='/' exact component={Dashboard}/>
        </Switch>
      </Layout>
      
    );
  }
}

export default App;
