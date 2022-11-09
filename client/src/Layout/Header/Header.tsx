import { AppBar, Button, IconButton, Switch, Toolbar, Typography } from '@mui/material';
import React from 'react';

export default function Header() 
{
    return <React.Fragment>
        <AppBar position="static" style={{marginBottom: '40px'}}>
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
          >
            
          </IconButton>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            News   <Switch defaultChecked color='secondary'/>
          </Typography>
          <Button color="inherit">Login</Button>
        </Toolbar>
      </AppBar>
    </React.Fragment>
}