
pub mod protoc;
pub mod basic_template_algorithm;
pub mod qc_algorithm;

use protobuf;
use protoc::qc::List_BaseData;
use qc_algorithm::QCAlgorithm;
use basic_template_algorithm::BasicTemplateAlgorithm;

#[no_mangle]
pub unsafe extern "C" fn init() -> *mut BasicTemplateAlgorithm {
    let algo = Box::new(BasicTemplateAlgorithm::new());

    Box::into_raw(algo)
}

#[no_mangle]
pub unsafe extern "C" fn Initialize(algo_ptr: *mut BasicTemplateAlgorithm) -> *mut BasicTemplateAlgorithm {
    let mut algo = Box::from_raw(algo_ptr);
    algo.Initialize();

    Box::into_raw(algo)
}

#[no_mangle]
pub unsafe extern "C" fn OnData(algo_ptr: *mut BasicTemplateAlgorithm, data: *mut u8, length: usize) -> *mut BasicTemplateAlgorithm {
    let mut algo = Box::from_raw(algo_ptr);
    let slice = std::slice::from_raw_parts(data, length);
    let list_data = protobuf::parse_from_bytes::<List_BaseData>(slice)
        .expect("Encountered bad protobuf data in OnData");

    algo.OnData(list_data.get_items());
    Box::into_raw(algo)
}

#[no_mangle]
pub unsafe extern "C" fn finalize(algo: *mut BasicTemplateAlgorithm) {
    Box::from_raw(algo);
}