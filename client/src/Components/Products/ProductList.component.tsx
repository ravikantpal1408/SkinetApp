import { Grid } from '@mui/material';
import { Products } from '../../Models/Products';
import ProductCard from './ProductCard.component';

interface Props {
    products: Products[]
}

 function ProductList({ products }: Props) {

    return (
        <Grid container spacing={4}>
        {products.map(product => (
            <Grid item xs={3} key={product.id}>
                <ProductCard product={product} />
            </Grid>
        ))}
    </Grid>
    )
}

export default ProductList;