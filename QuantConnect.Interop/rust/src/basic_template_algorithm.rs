use crate::qc_algorithm::QCAlgorithm;
use crate::protoc::qc;
pub struct BasicTemplateAlgorithm {
    points: u64
}

impl BasicTemplateAlgorithm {
    pub fn new() -> Self {
        Self {
            points: 0
        }
    }
}

impl QCAlgorithm for BasicTemplateAlgorithm {
    fn Initialize(&mut self) {
        println!("Hello from Rust :)");
    }

    fn OnData(&mut self, data: &[qc::BaseData]) {
        for point in data {
            self.points += 1;
        }

        println!("Got data!");
    }
}