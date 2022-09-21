import _ from 'lodash'
import { handleApi } from '../utils/handleApi'

export const state = () => ({
  notifySuccess: { show: false, text: '', message: '' },
  notifyError: { show: false, text: '', message: '' },
  notifyWarning: { show: false, text: '', message: '' },
  loading: false,
  email: '',
  isOtpPage: false
})

export const getters = {}

export const mutations = {
  setNotifySuccess(state, notify) {
    state.notifySuccess = _.cloneDeep(notify)
  },
  setNotifyError(state, notify) {
    state.notifyError = _.cloneDeep(notify)
  },
  setNotifyWarning(state, notify) {
    state.notifyWarning = _.cloneDeep(notify)
  },
  setLoading(state, loading) {
    state.loading = loading
  },
  setIsOtpPage(state, isOtpPage) {
    state.isOtpPage = isOtpPage
  },
  setEmail(state, email) {
    state.email = email
  }
}

export const actions = {
  uploadFile(context, data) {
    return new Promise((resolve, reject) => {
      handleApi(resolve, reject, this.$axios.post('/upload-image', data), context)
    })
  }
}
