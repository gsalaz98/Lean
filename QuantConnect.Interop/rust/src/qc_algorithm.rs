use crate::protoc::qc;

pub trait QCAlgorithm {
    fn Initialize(&mut self);
    fn OnData(&mut self, data: &[qc::BaseData]);
}