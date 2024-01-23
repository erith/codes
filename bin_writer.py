import struct
import numpy as np

def generate_random_float_array(size):
    # 랜덤한 32비트 float 배열 생성
    float_array = np.random.rand(size).astype(np.float32).tolist()
    return float_array

def write_float_array_to_file(file_path, float_array):
    # 'f'는 32비트 float를 나타내는 포맷 문자입니다.
    format_string = 'f' * len(float_array)

    # float 배열을 이진 데이터로 패킹합니다.
    packed_data = struct.pack(format_string, *float_array)

    # 이진 데이터를 파일에 쓰기 모드로 엽니다.
    with open(file_path, 'wb') as file:
        # 파일에 패킹된 데이터를 씁니다.
        file.write(packed_data)

# 예제로 사용할 크기 지정
array_size = 100000000 * 3

# 랜덤한 32비트 float 배열 생성
random_float_array = generate_random_float_array(array_size)

# 파일에 쓰기
file_path = 'data_1000M.bin'
write_float_array_to_file(file_path, random_float_array)

print(f'랜덤 Float 배열이 {file_path} 파일에 성공적으로 쓰여졌습니다.')
