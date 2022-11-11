import { createTheme, CssBaseline, ThemeProvider } from '@mui/material';
import { Container } from '@mui/system';
import React, { useState } from 'react';
import Catalog from './Components/Products/Catalog.component';
import Header from './Layout/Header/Header';
import SignIn from './Pages/SignIn';

function App() {
  const [darkMode, setDarkMode] = useState(false);
  const paletteType  = darkMode ? 'dark' : 'light';

  

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
      <SignIn/>
      {/* <ThemeProvider theme={theme}>
        <CssBaseline />
        <Header darkMode={darkMode} handleThemeChange={handleThemeChange} />
        <Container>
           <Catalog />

       </Container>
      </ThemeProvider> */}

    </React.Fragment>
  )
}


export default App;
