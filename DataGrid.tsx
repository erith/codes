import { CSSProperties } from 'react';
import { VariableSizeGrid as Grid } from 'react-window';
 
// These item sizes are arbitrary.
// Yours should be based on the content of the item.
const columnWidths = new Array(10)
  .fill(true)
  .map(() => 75 + Math.round(Math.random() * 50));
const rowHeights = new Array(100000)
  .fill(true)
  .map(() => 25 + Math.round(Math.random() * 50));
 
type  CellProps = {
    columnIndex: number;
    rowIndex: number;
    style:CSSProperties
}

const Cell = ({ columnIndex, rowIndex, style } : CellProps) => (
  <div style={style}>
    Item {rowIndex},{columnIndex}
  </div>
);
 
export const DataGrid = () => (
  <Grid
    columnCount={10}
    columnWidth={index => columnWidths[index]}
    height={550}
    rowCount={100000}
    rowHeight={index => rowHeights[index]}
    width={300}
  >
    {Cell}
  </Grid>
);
