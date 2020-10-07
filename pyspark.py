from pyspark import SparkConf, SparkContext
from pyspark.sql import SQLContext, Row
from pyspark.sql import SparkSession
import time

conf = SparkConf().setMaster("spark://centos7-1:7077").setAppName("MY APP")
conf.set("spark.executor.cores","2")
sc = SparkContext(conf = conf)

sqlContext = SQLContext(sc)

sql = "SELECT * FROM TAB WHERE SEQ < 1000"

time1 = time.time()

df1 = sqlContext.read.format("jdbc").option("url", "jdbc:mysql://192.168.0.71/bbs").option("driver", "org.mariadb.jdbc.Driver").option("query", sql).option("user", "root").option("password", "").load()

df1.cache()
