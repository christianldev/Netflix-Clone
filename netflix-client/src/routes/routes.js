import React from 'react';

//Layouts
import Header from '../layouts/Header';

// pages
import { Dashboard } from '../pages/Dashboard';

import { NotFound } from '../pages/NotFound';

const routes = [
  {
    index: true,
    layout: <Header />,
    element: <Dashboard />,
    exact: true,
  },
  //   {
  //     path: 'unauthorised',
  //     element: <Unauthorized />,
  //   },

  {
    path: '*',
    element: <NotFound />,
  },
];

export default routes;
