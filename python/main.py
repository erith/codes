from fastapi import FastAPI, HTTPException
import pandas as pd
from fastapi.encoders import jsonable_encoder
from fastapi.responses import JSONResponse, StreamingResponse
from pydantic import BaseModel
import pyarrow as pa
import pyarrow.parquet as pq
import io
from fastapi.middleware.cors import CORSMiddleware

app = FastAPI()


app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)


class Item(BaseModel):
    col1: str
    col2: str


@app.get("/")
async def read_root():
    return {"message": "Hello, World"}


@app.get("/test")
async def read_data():

    try:
        a = [10, 30, 20, 40]
        b = ['a', 'g', 'h', 'c']

        # 인덱스와 열 이름 지정
        df = pd.DataFrame({"Name": ['Tom', 'Nick', 'John', 'Peter'],
                           "Age": [15, 26, 17, 28]})

        table = pa.Table.from_pandas(df)
        buffer = io.BytesIO()
        pq.write_table(table, buffer)
        buffer.seek(0)
      # Parquet 파일 반환
        return StreamingResponse(
            iter([buffer.read()]),
            media_type="application/octet-stream",
            headers={"Content-Disposition": "attachment;filename=data.parquet"},
        )
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))

    # return JSONResponse(df.to_dict(orient='list'))
    # return JSONResponse(df.to_dict(orient='records'))


@app.get("/items/{item_id}")
async def read_item(item_id: int, q: str = None):
    return {"item_id": item_id, "q": q}
