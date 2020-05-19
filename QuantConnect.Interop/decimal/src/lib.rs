use rust_decimal::prelude::*;

#[repr(C)]
pub struct DecimalType {
    pub lo: u64,
    pub hi: u32,
    pub sign_scale: u32
}

#[no_mangle]
pub unsafe extern "C" fn to_f64(lo: u64, hi: u32, sign_scale: u32) -> f64 {
    let low = (lo & 0xFFFFFFFF) as u32;
    let mid = ((lo >> 32) & 0xFFFFFFFF) as u32;
    let high = hi;
    let negative = (sign_scale & 0x0001) == 0x0001;
    let scale = (sign_scale & 0x01FE) >> 1;

    let dec = Decimal::from_parts(low, mid, high, negative, scale);
    dec.to_f64().unwrap()
}

#[no_mangle]
pub unsafe extern "C" fn to_decimal(value: f64) -> DecimalType {
    let dec = Decimal::from_f64(value).unwrap();
    let bytes = dec.serialize();
    let mut bits = [0i32; 4];

    bits[0] = std::mem::transmute::<[u8; 4], i32>([bytes[0], bytes[1], bytes[2], bytes[3]]);
    bits[1] = std::mem::transmute::<[u8; 4], i32>([bytes[4], bytes[5], bytes[6], bytes[7]]);
    bits[2] = std::mem::transmute::<[u8; 4], i32>([bytes[8], bytes[9], bytes[10], bytes[11]]);
    bits[3] = std::mem::transmute::<[u8; 4], i32>([bytes[12], bytes[13], bytes[14], bytes[15]]);

    let a = (bits[1] as u64) << 32;
    let b = (bits[0] as u64) & 0xFFFFFFFF;
    let low = a | b;
    let high = bits[2] as u32;
    let sign_scale = (((bits[3] >> 15) & 0x01FE) | ((bits[3] >> 31) & 0x0001)) as u32;

    DecimalType {
        lo: low,
        hi: high,
        sign_scale: sign_scale
    }
}