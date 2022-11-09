import { Card, CardMedia, CardContent, Typography, CardActions, Button, Grid } from '@mui/material';
import React from 'react';
import { Products } from '../../Models/Products';

interface Props {
    products: Products[]
}

 function ProductList({ products }: Props) {

    console.log('props ', products);
    return (
        <React.Fragment>        
        <Grid container spacing={4} >
            {

                products.map(el => (

                    <Grid item xs={3} key={el.id} >
                        <Card sx={{ maxWidth: 345 }} className='custom-margin'>
                            <CardMedia
                                component="img"
                                height="140"
                                image={el.pictureUrl}
                                alt={el.name}
                            />
                            <CardContent className='upperBorder'>
                                <Typography gutterBottom variant="h5" component="div">
                                    {el.name}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    {el.description}
                                </Typography>
                            </CardContent>
                            <CardActions className='upperBorder'>
                                <Button size="small">Share</Button>
                                <Button size="small">Learn More</Button>
                            </CardActions>
                        </Card>
                    </Grid>

                ))

            }

        </Grid>
        </React.Fragment>
    )
}

export default ProductList;