import { createTheme, CssBaseline, ThemeProvider } from '@mui/material';
import { Container } from '@mui/system';
import React, { useState } from 'react';
import { Route } from 'react-router-dom';
import Catalog from './Components/Products/Catalog.component';
import ProductCard from './Components/Products/ProductCard.component';
import Header from './Layout/Header/Header';
import AboutPage from './Pages/About';
import ContactUs from './Pages/ContactUs';
import Home from './Pages/Home';
import SignIn from './Pages/SignIn';

function App() {
  const [darkMode, setDarkMode] = useState(false);
  const paletteType = darkMode ? 'dark' : 'light';
  const theme = createTheme({
    palette: {
      mode: paletteType,
      background: {
        default: paletteType === 'light' ? '#eaeaea' : '#121212'
      }
    }
  })

  function handleThemeChange() {
    setDarkMode(!darkMode);
  }

  return (
    <React.Fragment>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <Header darkMode={darkMode} handleThemeChange={handleThemeChange} />
        <Container>
          <Catalog/>
          <Route exact path='/' component={Home} />
          <Route exact path='/catalog' component={Catalog} />
          <Route exact path='/login' component={SignIn} />
          <Route path='/catalog/:id' component={ProductCard} />
          <Route exact path='/about' component={AboutPage} />
          <Route exact path='/contact' component={ContactUs} />
        </Container>
      </ThemeProvider>

    </React.Fragment>
  )
}


export default App;
