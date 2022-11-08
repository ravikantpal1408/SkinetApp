import { Card, CardMedia, CardContent, Typography, CardActions, Button, Grid } from '@mui/material';
import React from 'react';
import { Products } from '../../Models/Products';

interface Props {
    products: Products[]
}

 function ProductList({ products }: Props) {

    console.log('props ', products);
    return (
    <>
        <Grid container spacing={4} >
            {

                products.map(el => (

                    <Grid item xs={3} key={el.id} >
                        <Card sx={{ maxWidth: 345 }}>
                            <CardMedia
                                component="img"
                                height="140"
                                image={el.pictureUrl}
                                alt={el.name}
                            />
                            <CardContent>
                                <Typography gutterBottom variant="h5" component="div">
                                    {el.name}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    {el.description}
                                </Typography>
                            </CardContent>
                            <CardActions>
                                <Button size="small">Share</Button>
                                <Button size="small">Learn More</Button>
                            </CardActions>
                        </Card>
                    </Grid>

                ))

            }

        </Grid>
    </>
    )
}

export default ProductList;