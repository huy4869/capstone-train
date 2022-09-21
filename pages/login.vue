<template>
  <div class="main-login">
    <div>
      <div class="login login-width login-mobile">
        <h3 class="title">{{ $t('account.login_title') }}</h3>
        <el-form
          ref="accountForm"
          :model="accountForm"
          :rules="accountRules"
          autocomplete="off"
          label-position="left"
          @keyup.enter.native="login"
        >
          <el-form-item class="email-login" prop="email" :error="(error.key === 'email') ? error.value : ''">
            <label for="email">{{ $t('account.email') }}</label>
            <el-input
              id="email"
              ref="email"
              v-model.trim="accountForm.email"
              :placeholder="$t('account.email')"
              name="email"
              type="text"
              tabindex="2"
              maxlength="50"
              @focus="resetValidate('email')"
            />
          </el-form-item>
          <el-form-item class="email-login" prop="password" :error="(error.key === 'password') ? error.value : ''">
            <label for="password">{{ $t('account.password') }}</label>
            <el-input
              id="password"
              ref="password"
              v-model="accountForm.password"
              :placeholder="$t('account.password')"
              name="password"
              :type="showPass?'text':'password'"
              tabindex="3"
              maxlength="32"
              autocomplete="off"
              @focus="resetValidate('password')"
            >
              <i slot="suffix" class="cursor-pointer" @click="displayPass()">
                <img v-if="showPass" class="icon-show-pass" src="~/assets/images/icons/eye-input.svg" alt="showpass"/>
                <img v-else class="icon-show-pass" src="@/assets/images/icons/hide-eye.svg" alt="hidepass"/>
              </i>
            </el-input>
          </el-form-item>

          <el-form-item :error="(error.key === 'g-recaptcha-response') ? error.value : ''" prop="captcha" class="captcha">
            <template>
              <recaptcha
                ref="captcha"
                @error="onError"
                @success="onSuccess"
                @expired="onExpired"
              />
            </template>
          </el-form-item>
          <div class="d-flex align-items-center forgot-pass">
            <div
              class="content cursor-pointer login-page__forgot-password align-items-center" @click="$router.push('/forgot-pass')">
              {{ $t('account.forgot_password') }}
            </div>
          </div>
          <el-form-item>
            <div :class="{'disabled' : disabledButton, 'common-button': 'common-button'}">
              <el-button
                v-loading.fullscreen.lock="fullscreenLoading"
                :loading="loading"
                :disabled="disabledButton"
                @click.native="login"
              >
                {{ $t('account.login') }}
              </el-button>
            </div>
          </el-form-item>
          <div class="d-flex align-items-center no_account">
            <div
              class="content cursor-pointer login-page__forgot-password align-items-center" @click="step=3">
              {{ $t('account.no_account') }} <span class="here" @click="handeRegister">{{ $t('account.here')  }}</span>
            </div>
          </div>
        </el-form>
      </div>
    </div>
  </div>
</template>
<script>
// import { INDEX_SET_ERROR, INDEX_SET_LOADING } from '@/store/store.const'
import { validEmail } from '@/utils/validate'

export default {
  name: 'LoginPage',
  data() {
    const validdateEmail = (rule, value, callback) => {
      if (!validEmail(value)) {
        callback(new Error(this.$t('validation.email_format')))
      } else {
        callback()
      }
    }

    const validateCaptcha = (rule, value, callback) => {
      if (this.captcha == null || !this.captcha) {
        callback(new Error(this.$t('validation.captcha_req')))
      } else {
        callback()
      }
    }
    return {
      step: 1,
      token: '',
      captcha: '',
      isCaptchaExpireOrError: true,
      user: {},
      accountForm: {
        email: '',
        password: '',
        password_new_confirmation: '',
        remember: '',
        errors: {}
      },
      error: {
        key: null,
        value: ''
      },
      accountRules: {
        email: [
          {
            required: true,
            message: this.$t('validation.required', { _field_: this.$t('account.email') }),
            trigger: 'blur'
          },
          {
            validator: validdateEmail, trigger: 'blur'
          }
        ],
        password: [
          {
            required: true,
            message: this.$t('validation.required', { _field_: this.$t('account.password') }),
            trigger: 'blur'
          }
        ],
        captcha: [
          {
            validator: validateCaptcha, trigger: 'blur'
          }
        ],
        remember: []
      },
      valid: false,
      capsToolPasswordTip: false,
      loading: false,
      fullscreenLoading: false,
      showPass: false,
      isValid: false,
      isAuthErr: false
    }
  },
  computed: {
    disabledButton() {
      return this.accountForm.email === '' || this.accountForm.password === '' || this.captcha === ''
    }
  },
  methods: {
    handeRegister() {
      this.$router.push('/register')
    },
    resetValidate(ref) {
      if (ref === this.error.key) {
        this.error = { key: null, value: '' }
      }
      this.$refs.accountForm.fields.find((f) => f.prop === ref).clearValidate()
      this.accountForm.errors[ref] = ''
    },
    checkCapslock(e, attr) {
      const { key } = e
      this[attr] = key && key.length === 1 && (key >= 'A' && key <= 'Z')
    },
    async login() {
      // this.error = { key: null, value: '' }
      // this.validateForm()
      // if (!this.isValid) {
      //   return
      // }
      // try {
      //   this.$store.commit(INDEX_SET_LOADING, true)
      //   const token = await this.$recaptcha.getResponse()
      //   if (this.captcha == null || this.captcha !== token.toString()) {
      //     this.captcha = token.toString()
      //   }
      //   const dto = {
      //     email: this.accountForm.email,
      //     password: this.accountForm.password,
      //     'g-recaptcha-response': this.captcha
      //   }
      //   let { result } = {}
      //   result = await this.$auth.loginWith('local', {
      //     data: { ...dto }
      //   })
      //   const data = result.data
      //   switch (data.status_code) {
      //     case 200:
      //       await this.$router.push('/')
      //       break
      //     default:
      //       this.$store.commit(INDEX_SET_ERROR, { show: true, text: 'Lỗi !', message: data.message })
      //       break
      //   }
      // } catch (err) {
      //   this.$store.commit(INDEX_SET_ERROR, { show: true, text: 'Lỗi !', message: this.$t('message.message_error') })
      // }
      // if (this.isCaptchaExpireOrError) {
      //   this.captcha = ''
      // }
      // await this.$recaptcha.reset()
      // this.$store.commit(INDEX_SET_LOADING, false)
    },
    validateForm() {
      this.$refs.accountForm.validate(valid => {
        this.isValid = valid
      })
    },
    displayPass() {
      this.showPass = !this.showPass
    },
    async onError() {
      this.isCaptchaExpireOrError = true
      this.captcha = ''
      await this.$recaptcha.reset()
    },
    onSuccess(token) {
      this.isCaptchaExpireOrError = false
      this.captcha = token
      this.resetValidate('captcha')
    },
    async onExpired() {
      this.isCaptchaExpireOrError = true
      this.captcha = ''
      await this.$recaptcha.reset()
    },
    closeModalErr() {
      this.isAuthErr = false
    }
  }
}
</script>
<style scoped lang="scss">
</style>
