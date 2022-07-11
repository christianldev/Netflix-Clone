import './App.css';

import Navigation from './routes/Navigation';

import { Authentication } from './pages/Authentication';
import AuthContext from './context/AuthContext';
import { useEffect, useMemo, useState } from 'react';
import jwtDecode from 'jwt-decode';

function App() {
  const [auth, setAuth] = useState(undefined);
  const [error, setError] = useState('');

  useEffect(() => {
    const token = localStorage.getItem('token');

    if (!token) {
      setAuth(null);
    } else if (token) {
      const decoded = jwtDecode(token);
      const currentTime = Date.now() / 1000;
      if (decoded.exp < currentTime) {
        setAuth(null);
      } else {
        setAuth(decoded);
      }
    }
  }, []);

  const login = (userInfo) => {
    localStorage.setItem('token', userInfo);
    const user = jwtDecode(userInfo);
    setAuth(user);
  };

  const logout = () => {
    localStorage.removeItem('token');
    setAuth(null);
  };

  const authData = useMemo(
    () => ({
      auth,
      login,
      logout,
      error,
      setError,
    }),
    [auth],
  );

  if (auth === undefined) return null;

  return (
    <AuthContext.Provider value={authData}>
      {!auth ? <Authentication /> : <Navigation />}
    </AuthContext.Provider>
  );
}

export default App;
